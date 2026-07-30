import styled from "styled-components"
import { colors } from "../styles/colors"
import type { PropsWithChildren } from "react"

export default function MainCentralCard({children}: PropsWithChildren){
    return(
        <MainCardContainer>
            <MainCard>{children}</MainCard>
        </MainCardContainer>
    )
}

const MainCardContainer = styled.div`
    align-items: center;
    display: flex;
    flex-direction: column;
    margin: 2rem 0 2rem 0;
    justify-content: center;
    width: 100%;
`

const MainCard = styled.div`
    background-color: ${colors.mainCard};
    border-radius: .5em;
    display: flex;
    flex-direction: column;
    justify-content: space-around;
    padding: 1rem 0 1rem 0;
    width: 80%;
`