import styled from "styled-components";
import { genericInput, sizes } from "../styles/sizes";

interface InputComponent {
  setValue: React.Dispatch<React.SetStateAction<string>>;
  width: string;
  type: string;
  name: string;
  placeholder: string;
  id: string;
  value?: string,
  height?: string,
}

export function MyInput({ setValue, width, type, name, placeholder, id, value, height }: InputComponent) {
  return (
    <GenericInput
      type={type}
      onChange={(event) => setValue(event.target.value)}
      style={{ width: width, height: height, ...genericInput }}
      name={name}
      placeholder={placeholder}
      id={id}
      value={value}
    />
  );
}

const GenericInput = styled.input`
  height: ${sizes.inputHight};

  &::placeholder {
    ${genericInput.placeholder}
  }

  &:focus {
    ${genericInput.focus}
  }

  &:not(:focus) {
   ${genericInput.not}
  }
`;
