import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'slicedots'
})
export class SlicedotsPipe implements PipeTransform {

  transform(value: string, length: number): string {
    let res = value.slice(0, length);
    while(true) {
      if(value[length] != ' ' && value[length] != ',' && value[length] != '.') {
        res += value[length];
      }
      else break;
      length++;
    }
    return res + '...';
  }

}
