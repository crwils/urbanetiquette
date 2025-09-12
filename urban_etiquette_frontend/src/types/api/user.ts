import type { LocationDto } from "./location";

export type UserDto = {
  id: string
  firstName: string
  lastName: string
  email: string
  phoneNumber: string
  aboutMe: string
  location: LocationDto
}

export type CreateUserDto = {   
  firstName: string
  lastName: string
  email: string
  phoneNumber?: string
  aboutMe?: string
  location?: LocationDto
}

export type UpdateUserDto = CreateUserDto;