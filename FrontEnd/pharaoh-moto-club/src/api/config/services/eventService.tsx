import mainApiClient from "../mainAxiosInstance.ts";
import type { NewEvent, State } from "../../../types/globalTypes.tsx";
import axios from "axios";
import type { Params } from "react-router";

export async function getStatesAndCities() {
  try {
    const result = await mainApiClient.get<Array<State>>(`/events/states`);
    return result.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getCityEvents(city: string | undefined) {
  try {
    const result = await mainApiClient.get(`/events/city/${city}`);
    return result.data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      alert(error.response?.data.message);
    }
  }
}

export async function getEventyById(params: Readonly<Params<string>>) {
  try {
    const result = await mainApiClient.get(`/events/${params.eventId}`);
    return result.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getTypesOfEvent() {
  try {
    const result = await mainApiClient.get(`/TypeOfEvents`);
    return result.data;
  } catch (error) {
    console.log(error);
  }
}

export async function createNewEvent(newEvent: NewEvent) {
  try {
    const result = await mainApiClient.post(`/events/create`,
      newEvent
    );
    return result.data;
  } catch (error) {
    console.log(error);
  }
}


