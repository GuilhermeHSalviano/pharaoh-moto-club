import { useParams } from "react-router"

export default function SelectedEvent(){
    let params = useParams();
    console.log(params);
    return(
        <>
            <h1>Olá mundão</h1>
        </>
    )
}