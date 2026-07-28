export interface State {
  state: string;
  stateId: number;
  cities: [{city: string, cityId: number}];
}

export interface ApiError {
  message: string;
}

export interface StyleObject {
  property: string;
  value: string;
}

export type CustomCssStyles = {
  [key: string]: string;
};

export interface MyJwtPayload {
  name: string;
  nickname: string;
  nameid: string;
}

export interface Comment {
    eventId: string,
    authorId: string,
    commentText: string
}

export interface NewEvent{
  title: string,
  state: string,
  stateId: number,
  cityId: number,
  city: string,
  beginningOfEvent: Date,
  description: string,
  authorId: number,
  typeOfEventId: number
}
