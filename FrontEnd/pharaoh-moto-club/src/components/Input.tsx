import styled from "styled-components";
import { colors } from "../styles/colors";
import type { InputComponent } from "../types/Interfaces";
import { sizes } from "../styles/sizes";

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

  &::placeholder {
    color: ${colors.lines};
    font-family: "Big Shoulders Inline", sans-serif;
    padding-left: 1rem;
  }
`;
