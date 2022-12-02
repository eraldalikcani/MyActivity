import React from "react";
import { Message, MessageList } from "semantic-ui-react";

interface Props {
    errors: any;
}

export default function ValidationErrors({errors}: Props){
    return (
        <Message error>
            {errors && (
                <MessageList>
                    {errors.map((err: any, i: any) => (//i - index of the thing we're looping over
                        <Message.Item key={i}>{err}</Message.Item>
                    ))}
                </MessageList>
            )}
        </Message>
    )
}    