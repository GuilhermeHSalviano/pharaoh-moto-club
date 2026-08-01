import styled from "styled-components"
import { sizes } from "../styles/sizes"
import type { PropsWithChildren } from "react"

export function MainSection({children}:PropsWithChildren){
    return(
        <Section>{children}</Section>
    )
}

const Section = styled.main`
    align-items: center;
    display: flex;
    flex-direction: column;
    height: ${sizes.mainSection};
    overflow-y: auto;
    width: 100vw;
`