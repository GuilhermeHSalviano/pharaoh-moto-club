export interface State {
  state: string;
  stateId: number;
  cities: [{ city: string; cityId: number }];
}

export interface Claims{
  name: string,
  memberId: number,
  nickname: string
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
  eventId: string;
  authorId: string;
  commentText: string;
}

export interface NewEvent {
  title: string;
  state: string;
  stateId: number;
  cityId: number;
  city: string;
  beginningOfEvent: Date;
  description: string;
  authorId: number;
  authorName: string;
  typeOfEventId: number;
}

export interface CityFromIbge {
  id: number;
  nome: string;
  microrregiao: {
    id: number;
    nome: string;
    mesoregiao: {
      id: number;
      nome: string;
      UF: {
        id: number;
        nome: string;
        sigla: string;
        regiao: {
          id: number;
          nome: string;
          sigla: string;
        };
      };
    };
  };
  regiaoImediata: {
    id: number;
    nome: string;
    regiaoIntermediaria: {
      id: number;
      nome: string;
      UF: {
        id: number;
        nome: string;
        sigla: string;
        regiao: {
          id: number;
          nome: string;
          sigla: string;
        };
      };
    };
  };
}

export interface TypeOfEvent{
  typeOfEventId: number,
  description: string
}
