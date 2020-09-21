import { EntryDto } from './entrydto';

export interface PhoneBookDto {
    id: string;
    name: string;
    entries: EntryDto[];
}
