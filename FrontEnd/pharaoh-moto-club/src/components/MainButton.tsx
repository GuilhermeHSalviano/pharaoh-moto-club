import styled from "styled-components";
import { colors } from "../styles/colors";
import { sizes } from "../styles/sizes";
import { fonts } from "../styles/fonts";

interface MainGenericButton{
  doOnClick: () => void; 
  title: string;
}

export function MainButton({doOnClick, title}: MainGenericButton) {
  return (
    <>
      <MyButton onClick={()=> doOnClick()}>{title}</MyButton>
    </>
  );
}

const MyButton = styled.button`
    background-color: ${colors.mainButtonBackground};
    border-radius: ${sizes.borderButton};
    border: none;
    box-shadow: ${sizes.buttonShadow};
    font-family: ${fonts.labelFont};
    font-size: 1.3rem;
    height: ${sizes.heightButton};
    width: ${sizes.widthButton};

    &:active{
      opacity: 50%;
    }
`;
