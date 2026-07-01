import styled from "styled-components"
import { colors } from "../styles/colors"
import type { StyleObject } from "../types/globalTypes"
import { convertStyleObjectIntoCssStyles } from "../utilFunctions"

interface Props{
    description: string,
    aditionalStyles?: StyleObject[]
}

export default function SmallTitle({description, aditionalStyles}: Props){
    return(
        <Title style={aditionalStyles != undefined? convertStyleObjectIntoCssStyles(aditionalStyles): {}}>{description}</Title>
    )
}

const Title = styled.h4`
    color: ${colors.smallTitle}
`