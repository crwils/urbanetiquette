import { useUsers } from "./services/users/users";
import type { UserDto } from "./types/api/user";

const TanstackTest = () => {
    const { data, isLoading, error } = useUsers();
    console.log({data, isLoading, error});

    if (isLoading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error.message}</div>;
    }
    return (
        <div>
            <h1>TanstackTest</h1>
            {data?.map((user: UserDto) => (
                <div key={user.id}>{user.firstName} {user.lastName}</div>
            ))}
        </div>
    );
};

export default TanstackTest;
