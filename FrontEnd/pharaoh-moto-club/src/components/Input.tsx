import styled from "styled-components"
import { colors } from "../styles/colors"
import type { InputFunction } from "../types/Interfaces";


export function MyInput({setValue}: InputFunction  ){

    return(
        <GenericInput type="text" onChange={event => setValue(event.target.value)}/>
    )
}

const GenericInput = styled.input`
    background-color: ${colors.inputBackground};
`