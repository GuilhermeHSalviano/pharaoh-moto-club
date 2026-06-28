import apiClient from "../axiosInstance";

export async function getTokenByLoggingIn(userEmail: string, userPassword: string) {

  return await apiClient.post(`/members/login`, {
    Email: userEmail,
    password: userPassword,
  });
}
