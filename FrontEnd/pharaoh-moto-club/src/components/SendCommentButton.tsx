import styled from "styled-components";
import type { Comment } from "../types/globalTypes";
import { createComment } from "../api/config/services/commentService";
import { fonts } from "../styles/fonts";

export default function SendCommentButton({
  eventId,
  authorId,
  commentText,
}: Comment) {
  async function sendComment() {
    if(commentText == "") alert("Insira um comentário antes de enviar");
    let comment = await createComment({ eventId, authorId, commentText });
    comment.status != 201 ? alert("Houve um erro ao enviar o comentário") : "";
  }

  return <SendComment onClick={()=> sendComment()}>Enviar</SendComment>;
}

const SendComment = styled.button`
    font-family: ${fonts.dateNumber};
    height: 3em;
    padding: .3em;
`;
