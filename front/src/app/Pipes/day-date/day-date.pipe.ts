import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'day-date'
})
export class DayDatePipe implements PipeTransform {

  transform(value: string): string {
    const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    const date = new Date(value);
    const dayName = days[date.getDay()];
    const formattedDate = `${dayName} ${date.getDate()}/${date.getMonth() + 1}`;
    return formattedDate;
  }
}
