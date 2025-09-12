import type { UserDto } from "../../types/api/user";
import { useApiQuery } from "../common/useApiQuery";

export const useUsers = () => 
  useApiQuery<UserDto[]>(['users'], '/users');
