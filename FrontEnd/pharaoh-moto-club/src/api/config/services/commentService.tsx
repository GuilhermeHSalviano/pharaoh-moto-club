import type { Comment } from "../../../types/globalTypes";
import apiClient from "../axiosInstance";
import axios from "axios";

export async function createComment({eventId, authorId, commentText}: Comment) {
  try {
    const result = await apiClient.post(`comments/${eventId}/${authorId}`, commentText)
    return result.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      alert(error.response?.data.message);
    }
  }
}
