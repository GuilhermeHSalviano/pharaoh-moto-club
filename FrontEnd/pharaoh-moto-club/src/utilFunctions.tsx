export function getDay(date: Date): string{
    let fullDate = new Date(date).getDate();    
    let formattedDate = fullDate.toLocaleString.length < 2 ? 0 + fullDate.toLocaleString(): fullDate.toLocaleString();
    return formattedDate;
}

export function getMonth(date: Date): string{
    let fullDate = new Date(date);
    return fullDate.toLocaleString('pt-BR', { month: 'short' });
}

export function getDate(date: Date): string{
    let fullDate = new Date(date);    
    let formattedDate = fullDate.toLocaleDateString('pt-BR');
    return formattedDate;
}

export function getTime(date: Date): string{
    let fullDate = new Date(date);    
    let hours = fullDate.getHours();
    let minutes = fullDate.getMinutes();

    return `${hours}:${minutes}`;
}

