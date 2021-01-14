/* eslint-disable react/jsx-props-no-spreading */
import React from 'react';
import ChatBot from 'react-simple-chatbot';
import { ThemeProvider } from 'styled-components';

function CustomChatbot() {
  const config = {
    width: '250px',
    height: '350px',
    floating: true,
  };

  const theme = {
    background: 'white',
    fontFamily: 'Arial, Helvetica, sans-serif',
    headerBgColor: '#24292e',
    headerFontColor: '#fff',
    headerFontSize: '25px',
    botBubbleColor: '#24292e',
    botFontColor: '#fff',
    userBubbleColor: '#fff',
    userFontColor: '#4c4c4c',
  };

  const steps = [
    {
      id: 'Greet',
      message: 'Welcome!',
      trigger: 'Ask Name',
    },
    {
      id: 'Ask Name',
      message: "Are you ready to party? What's your name?",
      trigger: 'Waiting user input for name',
    },
    {
      id: 'Waiting user input for name',
      user: true,
      trigger: 'Asking about party places',
    },
    {
      id: 'Asking about party places',
      message: 'Hi {previousValue}! What is your fav city?',
      trigger: 'Waiting user input about city',
    },
    {
      id: 'Waiting user input about city',
      options: [
        {
          value: 'zagreb',
          label: 'Zagreb',
          trigger: 'Here are the clubs in Zagreb...',
        },
        {
          value: 'split',
          label: 'Split',
          trigger: 'Here are the clubs in Split...',
        },
        {
          value: 'osijek',
          label: 'Osijek',
          trigger: 'Here are the clubs in Osijek...',
        },
      ],
    },
    {
      id: 'Here are the clubs in Zagreb...',
      message: "Zagreb's best clubs: H2O, Mint, BBS, Zags...",
      trigger: 'Done',
    },
    {
      id: 'Here are the clubs in Split...',
      message: "Split's best clubs: Vanilla, Kauri, Tempera...",
      trigger: 'Done',
    },
    {
      id: 'Here are the clubs in Osijek...',
      message: "Osijek's best clubs: Q-Club, Matrix, Exit...",
      trigger: 'Done',
    },
    {
      id: 'Done',
      message: 'You should make reservation in one!',
      end: true,
    },
  ];
  return (
    <ThemeProvider theme={theme}>
      <ChatBot steps={steps} {...config} />
    </ThemeProvider>
  );
}
export default CustomChatbot;
