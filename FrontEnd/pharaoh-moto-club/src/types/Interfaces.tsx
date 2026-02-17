
export interface InputComponent {
  setValue: React.Dispatch<React.SetStateAction<string | undefined>>;
  width: string;
  type: string;
  name: string;
  placeholder: string;
  id: string
}

export interface MainGenericButton{
  doOnClick: () => void; 
  title: string;
}

export interface NavComponent{
  title: string;
}