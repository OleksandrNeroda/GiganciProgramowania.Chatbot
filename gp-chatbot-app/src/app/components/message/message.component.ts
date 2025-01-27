import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Rating } from '../../common/rating.enum';
import { CommonModule } from '@angular/common';
import {Message} from './message.interface';
import {ChatService} from '../../common/services/chat.service';
import {MatIcon} from '@angular/material/icon';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss'],
  imports: [CommonModule, MatIcon]
})
export class MessageComponent {
  @Input() message?: Message;

  constructor(private chatService: ChatService) {}

  onRate(messageRate: Rating) {
    if (this.message?.messageRateCode !== messageRate) {
      const previousRateCode = this.message?.messageRateCode!;

      this.chatService.rateMessage(this.message?.messageId!, messageRate).subscribe(
        (res: any) => {
          this.message!.messageRateCode = messageRate.toString();
        },
        (error) => {
          this.message!.messageRateCode = previousRateCode;
          console.error('Failed to rate the message', error);
        }
      );
    }
  }

  protected readonly Rating = Rating;
}
