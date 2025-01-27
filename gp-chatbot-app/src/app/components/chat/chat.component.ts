import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MessageComponent } from '../message/message.component';
import { Rating } from '../../common/rating.enum';
import { ChatService } from '../../common/services/chat.service';
import {Message} from '../message/message.interface';

@Component({
  selector: 'app-chat',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatListModule,
    MessageComponent,
  ],
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit {
  messages: Message[] = [];
  userInput: string = '';
  isTyping = false;
  private cancelTyping = false;

  constructor(private chatService: ChatService) {}

  ngOnInit() {
    this.loadChatHistory();
  }

  loadChatHistory() {
    this.chatService.getAllMessages().subscribe((response: Message[]) => {
      this.messages = response;
    });
  }

  sendMessage() {
    if (this.userInput.trim()) {
      const userMessage: Message = {
        messageId: 'newMessage',
        message: this.userInput,
        messageRateCode: Rating.Missing,
        isUserMessage: true
      };

      this.messages.push(userMessage);

      this.isTyping = true;
      this.cancelTyping = false;

      this.chatService.sendMessage(this.userInput).subscribe({
        next: (botResponse:Message) => {
          const botMessage: Message = {
            messageId: botResponse.messageId,
            message: '',
            messageRateCode: botResponse.messageRateCode,
            isUserMessage: false
          };

          this.messages.push(botMessage);
          this.simulateTyping(botResponse.message, botMessage).then(() => {
            this.isTyping = false;
          });
        },
        error: (error) => {
          console.error('Error while sending message:', error);
          this.isTyping = false;
        },
        complete: () => {
          this.userInput = '';
        }
      });
    }
  }

  async simulateTyping(response: string, botMessage: Message) {
    const typingSpeed = 20;
    const messageIndex = this.messages.indexOf(botMessage);

    for (let i = 0; i < response.length; i++) {
      if (this.cancelTyping) {
        break;
      }
      await this.delay(typingSpeed);
      this.messages[messageIndex].message += response[i];
    }

    this.isTyping = false;
    this.messages[messageIndex].messageRateCode = Rating.Missing;
  }

  cancelResponse() {
    this.cancelTyping = true;
    this.isTyping = false;
    const lastMessage = this.messages[this.messages.length - 1];
    if (lastMessage && lastMessage.messageRateCode === 'typing') {
      lastMessage.messageRateCode = 'canceled'; // Oznaczenie, że odpowiedź została anulowana
    }
  }

  delay(ms: number): Promise<void> {
    return new Promise((resolve) => setTimeout(resolve, ms));
  }
}
