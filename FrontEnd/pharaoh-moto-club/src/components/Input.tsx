import styled from "styled-components";
import { colors } from "../styles/colors";
import { sizes } from "../styles/sizes";

interface InputComponent {
  setValue: React.Dispatch<React.SetStateAction<string>>;
  width: string;
  type: string;
  name: string;
  placeholder: string;
  id: string
}

export function MyInput({ setValue, width, type, name, placeholder, id }: InputComponent) {
  return (
    <GenericInput
      type={type}
      onChange={(event) => setValue(event.target.value)}
      style={{ width: width }}
      name={name}
      placeholder={placeholder}
      id={id}
    />
  );
}

const GenericInput = styled.input`
  background-color: ${colors.inputBackground};
  box-shadow: ${sizes.inputShadow};
  border-radius: ${sizes.borderInput};
  border: none;
  height: ${sizes.inputHight};
  padding-left: 1rem;

  &::placeholder {
    color: ${colors.lines};
    font-family: "Big Shoulders Inline", sans-serif;
  }

  &:focus {
    color: white;
    font-family: "Big Shoulders Inline", sans-serif;
  }

  &:not(:focus) {
    color: white;
    font-family: "Big Shoulders Inline", sans-serif;
  }
`;
