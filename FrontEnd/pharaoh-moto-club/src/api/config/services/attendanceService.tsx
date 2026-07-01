import apiClient from "../axiosInstance";
import axios from "axios";

export async function quitEvent(eventId: string, memberId: string) {
  try {
    const result = await apiClient.delete(`eventattendant/quit/${eventId}/${memberId}`)
    return result.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      alert(error.response?.data.message);
    }
  }
}

export async function confirmAttendance(eventId: string, memberId: string) {
  try {
    const result = await apiClient.post(`eventattendant/${eventId}/${memberId}`)
    return result.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      alert(error.response?.data.message);
    }
  }
}


