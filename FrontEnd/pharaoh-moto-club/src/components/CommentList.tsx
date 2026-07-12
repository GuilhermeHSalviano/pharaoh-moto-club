import styled from "styled-components";
import { getDate, getTime } from "../utilFunctions";

type Comments = {
  commentList: [
    {
      commentText: string;
      commentDate: Date;
      author: string;
    },
  ];
};

export default function CommentList({ commentList }: Comments) {
  return(
    <CommentsBaloon>
        {commentList&&
            commentList.map(comment => (
                <CommentDiv key={String(comment.commentDate)}>
                    <Author>{`${comment.author}: `}</Author>
                    <DateAndTextDiv>
                        <Date>{`${getDate(comment.commentDate)} - ${getTime(comment.commentDate)}` }</Date>
                        <Text>{comment.commentText}</Text>
                    </DateAndTextDiv>
                </CommentDiv>
            ))
        }
    </CommentsBaloon>
  ) 
}

const CommentsBaloon = styled.div`
    align-self: center;
    background-color: white;
    border-radius: 1em;
    display: flex;
    flex-direction: column;
    padding: .5em;
    width: 95%;
`;

const CommentDiv = styled.ul`
    display: flex;
    margin: .5em 0 .5em 0;
`

const Author = styled.h4`
    
`

const DateAndTextDiv = styled.h3`
    flex-direction:  column;
    display: flex;
    padding: 0 .3em 0 .3em;
`

const Date = styled.p`
    
`
const Text = styled.p`
    
`
