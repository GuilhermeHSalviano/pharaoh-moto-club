import apiClient from "../axiosInstance";

export async function getTokenByLoggingIn(userCpf: string, userPassword: string) {

  return await apiClient.post(`/members/login`, {
    cpf: userCpf,
    password: userPassword,
  });
}
