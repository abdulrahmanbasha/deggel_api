export interface book { 
    id: string;
    first_name: string;
    last_name: string;
    email: string;
    phone_number: string;
    country: string;
    city: string;
    special_requirements: string;
    booking_status:	string;
    booking_payment:  booking_payment[];
}

export interface booking_payment {
    id: number;
    payment_method: string;
    phone_number: string;
    payment_amount: number;
    payment_reference: string;
    payment_date: Date;
    payment_made_by: string;
    payment_status: string;
}