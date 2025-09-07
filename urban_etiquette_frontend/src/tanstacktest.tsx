import { useQuery } from "@tanstack/react-query";

type ApiResponse<T> = {
    data: T[];
};

type DogBreed = {
    id: string;
    type: string;
    attributes: {
        name: string;
        description: string;
    };
};

const TanstackTest = () => {
    const { data, isLoading, error } = useQuery<ApiResponse<DogBreed>>({
        queryKey: ["dog-breeds"],
        queryFn: async () => {
            const response = await fetch("https://dogapi.dog/api/v2/breeds");
            if (!response.ok) {
                throw new Error("Network response was not ok");
            }
            return response.json();
        },
    });

    if (isLoading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error.message}</div>;
    }
    return (
        <div>
            <h1>TanstackTest</h1>
            {data.data?.map((dog: DogBreed) => (
                <div key={dog.id}>{dog.attributes.name}</div>
            ))}
        </div>
    );
};

export default TanstackTest;
