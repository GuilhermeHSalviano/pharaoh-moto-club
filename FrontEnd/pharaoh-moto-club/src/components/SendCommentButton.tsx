import styled from "styled-components";
import type { Comment } from "../types/globalTypes";
import { createComment } from "../api/config/services/commentService";
import { fonts } from "../styles/fonts";

interface Props extends Comment {
  refetch: Function;
  eraseInput: Function
}

export default function SendCommentButton({
  eventId,
  authorId,
  commentText,
  refetch,
  eraseInput
}: Props) {
  async function sendComment() {
    if (commentText == "") {
      alert("Insira um comentário antes de enviar");
    } else {
      await createComment({ eventId, authorId, commentText });
      eraseInput("");
      refetch();
    }
  }

  return <SendComment onClick={() => sendComment()}>Enviar</SendComment>;
}

const SendComment = styled.button`
  font-family: ${fonts.dateNumber};
  height: 3em;
  padding: 0.3em;
`;
