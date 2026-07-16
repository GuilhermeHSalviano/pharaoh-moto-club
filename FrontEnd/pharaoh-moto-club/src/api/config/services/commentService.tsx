import type { Comment } from "../../../types/globalTypes";
import mainApiClient from "../mainAxiosInstance";
import axios from "axios";

export async function createComment({eventId, authorId, commentText}: Comment) {
  try {
    const result = await mainApiClient.post(`comments/create/${eventId}/${authorId}`, {commentText})
    return result.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      alert(error.response?.data.message);
    }
  }
}
