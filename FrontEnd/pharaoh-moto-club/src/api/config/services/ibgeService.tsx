import ibgeApiClient from "../ibgeAxiosInstance";
import axios from "axios";

export async function getStatesFromIbge() {
    type Estado = {sigla: string, id: string}
  try {
    const result = await ibgeApiClient.get("/estados");
    let orderedResult: Estado[];
    orderedResult = [...result.data].sort((a, b) => a.sigla.localeCompare(b.sigla))
    return orderedResult;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      alert(error.response?.data.message);
    }
  }
}

export async function getCitiesFromIbgeById(stateId: string) {
  try {
    const result = await ibgeApiClient.get(`/estados/${stateId}/municipios`);
    return result.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      alert(error.response?.data.message);
    }
  }
}