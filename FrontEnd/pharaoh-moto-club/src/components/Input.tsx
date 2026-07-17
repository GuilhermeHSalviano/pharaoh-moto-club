import styled from "styled-components";
import { colors } from "../styles/colors";
import { sizes } from "../styles/sizes";
import { fonts } from "../styles/fonts";

interface InputComponent {
  setValue: React.Dispatch<React.SetStateAction<string>>;
  width: string;
  type: string;
  name: string;
  placeholder: string;
  id: string;
  value?: string
}

export function MyInput({ setValue, width, type, name, placeholder, id, value }: InputComponent) {
  return (
    <GenericInput
      type={type}
      onChange={(event) => setValue(event.target.value)}
      style={{ width: width }}
      name={name}
      placeholder={placeholder}
      id={id}
      value={value}
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
    font-family: ${fonts.inputFont};
  }

  &:focus {
    color: white;
    font-family: ${fonts.inputFont};
  }

  &:not(:focus) {
    color: white;
    font-family: ${fonts.inputFont};
  }
`;
