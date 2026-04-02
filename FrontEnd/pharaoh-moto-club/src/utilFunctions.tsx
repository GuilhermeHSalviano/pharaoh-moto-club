export function getDay(date: Date): string{
    let fullDate = new Date(date).getDate();    
    let formattedDate = fullDate.toLocaleString.length < 2 ? 0 + fullDate.toLocaleString(): fullDate.toLocaleString();
    return formattedDate;
}

export function getMonth(date: Date): string{
    let fullDate = new Date(date);
    return fullDate.toLocaleString('pt-BR', { month: 'short' });
}