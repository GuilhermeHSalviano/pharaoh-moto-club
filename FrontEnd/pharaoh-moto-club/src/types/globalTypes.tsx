export interface State {
    state: string;
    stateId: number;
    cities: [city: string, cityId: number];
}

export interface ApiError{
    message: string
}

