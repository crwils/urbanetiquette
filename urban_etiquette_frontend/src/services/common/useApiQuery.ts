import { useQuery } from "@tanstack/react-query";
import { apiRequest } from "./api";

export const useApiQuery = <T>(
    key: string[],
    endpoint: string,
    options?: { enabled?: boolean }
) => {
    return useQuery({
        queryKey: key,
        queryFn: () => apiRequest<T>(endpoint),
        enabled: options?.enabled,
    });
};

// Usage example:
// const { data, isLoading, error } = useApiQuery<User[]>(['users'], '/users');
