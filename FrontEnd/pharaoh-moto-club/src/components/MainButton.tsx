import styled from "styled-components";
import type { MainGenericButton } from "../types/Interfaces";
import { colors } from "../styles/colors";

export function MainButton({doOnClick, title}: MainGenericButton) {
  return (
    <>
      <MyButton onClick={()=> doOnClick()}>{title}</MyButton>
    </>
  );
}

const MyButton = styled.button`
    background-color: ${colors.mainButtonBackground};
`;
