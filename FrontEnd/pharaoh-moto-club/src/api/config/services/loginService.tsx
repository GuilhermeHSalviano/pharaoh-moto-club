import mainApiClient from "../mainAxiosInstance";

export async function authenticateAndGetClaims(userEmail: string, userPassword: string) {

  return await mainApiClient.post(`/members/login`, {
    Email: userEmail,
    password: userPassword,
  });
}
