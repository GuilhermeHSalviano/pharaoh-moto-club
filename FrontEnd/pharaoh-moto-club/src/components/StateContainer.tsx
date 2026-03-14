import styled from "styled-components"
import { colors } from "../styles/colors"
import type { State } from "../interfaces.tsx";


export function StateContainer({state, stateId, cities}: State){
    return(
        <>
            <Container>
                <State>{state}</State>
            </Container>
        </>
    )
}

const Container = styled.div`
    background-color: ${colors.footerIcons};
    border-radius: 1rem;
    height: 5rem;
    width: 80%;
`

const State = styled.h2`
    color: ${colors.mainButtonBackground};
`