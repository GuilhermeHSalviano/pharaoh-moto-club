import apiClient from "../axiosInstance";
import type { State } from "../../../types/globalTypes.tsx";
import axios from "axios";

export async function getStatesAndCities() {
  try {
    const result = await apiClient.get<Array<State>>(`/events/states`);
    return result.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getCityEvents(city: string | undefined) {
  try {
    const result = await apiClient.get(`/events/city/${city}`);
    return result.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      alert(error.response?.data.message);
    }
  }
}
