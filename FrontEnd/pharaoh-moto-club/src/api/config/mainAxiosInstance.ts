import axios, { AxiosError } from "axios";

const mainApiClient = axios.create({
  baseURL: `http://${window.location.hostname}:5000`,
  withCredentials: true,
});

mainApiClient.interceptors.response.use(
  (response) => {
    return response;
  },
  async (error: AxiosError) => {
    if (!axios.isAxiosError(error)) {
      return Promise.reject(error);
    }
    const originalRequest = error.config as (NonNullable<typeof error.config> & {
      _retry?: boolean;
    });

    if (!originalRequest) {
      return Promise.reject(error);
    }

    if (originalRequest.url === "/members/refreshToken" || originalRequest._retry) {
      return Promise.reject(error);
    }

    if (error.response?.status === 401) {
      try {
        originalRequest._retry = true;
        await mainApiClient.post("/members/refreshToken");
        return mainApiClient(originalRequest);
      } catch {
        window.location.href = "/";
        return Promise.reject(error);
      }
    }

    return Promise.reject(error);
  },
);

export default mainApiClient;
