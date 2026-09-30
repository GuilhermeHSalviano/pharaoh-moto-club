import styled from "styled-components";
import { fonts } from "../styles/fonts";

type Props = {
    title: string
};

export default function ThereIsNothingToRender({title}: Props){
    return(
        <Container>
            <Title>{title}</Title>
        </Container>
    )
}

const Container = styled.div`
  align-items: center;
  display: flex;
  justify-content: center;
`

const Title = styled.h2`
  color: aliceblue;
  font-family: ${fonts.cardFont};
  font-size: 1.5rem;
  margin-top: 3rem;
  text-align: center;
`