import styled from "styled-components"

export default function Loading(){
    return(
        <LoadingData>Carregando</LoadingData>
    )
}

const LoadingData = styled.h2`
    align-self: center;
    color: white;
    flex-grow: 2;
`