// services/users.api.ts
import { useApiQuery } from '../common/useApiQuery';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import { apiRequest } from '../common/api';
import type { UserDto, CreateUserDto, UpdateUserDto } from '../../types/api/user';

export const useUser = (id: string) => 
  useApiQuery<UserDto>(['users', id], `/users/${id}`);

// Mutations (POST, PUT, DELETE operations)
export const useCreateUser = () => {
  const queryClient = useQueryClient();
  
  return useMutation({
    mutationFn: (user: CreateUserDto) => 
      apiRequest<UserDto>('/users', {
        method: 'POST',
        body: JSON.stringify(user),
      }),
    onSuccess: () => {
      // Invalidate users list to refetch
      queryClient.invalidateQueries({ queryKey: ['users'] });
    },
  });
};

export const useUpdateUser = () => {
  const queryClient = useQueryClient();
  
  return useMutation({
    // ✅ Use UpdateUserDto + id parameter
    mutationFn: ({ id, ...user }: UpdateUserDto & { id: string }) =>
      apiRequest<UserDto>(`/users/${id}`, {
        method: 'PUT',
        body: JSON.stringify(user),
      }),
    onSuccess: (data) => {
      queryClient.setQueryData(['users', data.id], data);
      queryClient.invalidateQueries({ queryKey: ['users'] });
    },
  });
};

export const useDeleteUser = () => {
  const queryClient = useQueryClient();
  
  return useMutation({
    mutationFn: (id: string) =>
      apiRequest(`/users/${id}`, { method: 'DELETE' }),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['users'] });
    },
  });
};