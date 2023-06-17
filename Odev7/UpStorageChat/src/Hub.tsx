import React, { useEffect, useState } from 'react';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

type Message = {
    userName: string,
    content: string,
    createdOn: Date
}

const ChatComponent: React.FC = () => {
    const [connection, setConnection] = useState<HubConnection | null>(null);
    const [messages, setMessages] = useState<Message[]>([]);
    const [message, setMessage] = useState<string>('');
  //  const [user, setUser] = useState<string>('');

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:7054/Hubs/ChatHub')
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    console.log('SignalR connected');
                })
                .catch((error: Error) => {
                    console.log('SignalR connection error: ', error);
                });
        }
    }, [connection]);

    useEffect(() => {
        if (connection) {
            connection.on('MessageAdded', (message: Message) => {
                setMessages((prevMessages) => [...prevMessages, message]);
            });
        }
    }, [connection]);

    const sendMessage = () => {
        if (connection) {
            connection.invoke('SendMessage', message)
                .catch((error: Error) => {
                    console.log('SendMessage error: ', error);
                });

            setMessage('');
        }
    };

    return (
        <div>
            <div>
                {messages.map((msg, index) => (
                    <p key={index}>{msg.content} {msg.userName}</p>
                ))}
            </div>

            <input type="text" value={message} onChange={(e) => setMessage(e.target.value)} />
            <button onClick={sendMessage}>Send Message</button>
        </div>
    );
};

export default ChatComponent;
