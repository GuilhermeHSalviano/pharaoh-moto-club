import styled from "styled-components";
import { MainBackgroundDiv } from "../components/MainBackgroundDiv";
import MainCentralCard from "../components/MainCentralCard";
import { MainSection } from "../components/MainSection";
import { MyFooter } from "../components/MyFooter";
import { Nav } from "../components/Nav";
import { fonts } from "../styles/fonts";
import { colors } from "../styles/colors";
import { MyInput } from "../components/Input";
import { useState } from "react";

export default function CreateEvent(){
    const [titleInput, setTitleInput] = useState("");

    

    return(
        <MainBackgroundDiv>
            <Nav title="Criar evento"></Nav>
            <MainSection>
                <MainCentralCard>
                    <TitleInputContainer>
                        <Title>{"Título"}</Title>
                        <MyInput
                            width={"100%"}
                            setValue={setTitleInput}
                            type={"text"}
                            name={"titleInput"}
                            placeholder={"Nome do evento"}
                            id={"title"}
                        ></MyInput>
                    </TitleInputContainer>
                    <StateInputContainer>
                        <State>{"Estado"}</State>
                        <StateInput></StateInput>
                    </StateInputContainer>
                </MainCentralCard>
            </MainSection>
            <MyFooter></MyFooter>
        </MainBackgroundDiv>
    )
}

const TitleInputContainer = styled.div`
    display: flex;
    flex-wrap: wrap;
    margin-bottom: 1em;
    padding: 2em 2em 0 2em;
    width: 100%;
`

const Title = styled.h2`
    align-self: flex-start;
    color: ${colors.titleInDarkBackground};
    font-family: ${fonts.labelFont};
    font-size: 1.5em;
    width: 100%;
`

const StateInputContainer = styled.div`
    display: flex;
    flex-direction: column;
    margin-bottom: 1em;
    padding: 0 2em 0 2em;
    width: 30%;
`

const State = styled.h2`
    align-self: flex-start;
    color: ${colors.titleInDarkBackground};
    font-family: ${fonts.labelFont};
    font-size: 1.5em;
`

const StateInput = styled.select`
    
`
