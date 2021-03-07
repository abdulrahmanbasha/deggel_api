export interface hotel_detail { 
    id: string;
    hotel_name: string;
    description: string;
    stars: number;
    image_url: string;
    address: Address;
    rooms: Room[];
    files: File[];
    amenities: Amenity;
    addresses: Address[];
    ratings: Rating[];
    reviews: Review[];
    nearest_essentials: NearestEssential[];
    nearby_places: NearbyPlace[];
    house_rules: HouseRule[];
    nearby_hotels: NearbyHotel[];
}



export interface Address {
    id: number;
    longitude: number;
    latitude: number;
    area: string;
    city: string;
}

export interface File {
    id: number;
    file_url: string;
}

export interface RoomAmenity { 
    id: number;
    wifi: boolean;
    fitness_center: boolean;
    cafeteria: boolean;
    restaurant: boolean;
    bathrobes: boolean;
    dry_cleaning: boolean;
    high_chair: boolean;
    slipper: boolean;
    wakeup_call: boolean;
    telephone: boolean;
    air_conditioning: boolean;
    parking: boolean;
}

export interface Room {
    id: number;
    room_type: string;
    files: File[];
    room_amenity: RoomAmenity;
    room_beds: number;
    floor_number: number;
    room_price: number;
}

export interface File {
    id: number;
    file_url: string;
}

export interface Amenity {
    id: number;
    wifi: boolean;
    fitness_center: boolean;
    cafeteria: boolean;
    restaurant: boolean;
    bathrobes: boolean;
    dry_cleaning: boolean;
    high_chair: boolean;
    slipper: boolean;
    wakeup_call: boolean;
    telephone: boolean;
    air_conditioning: boolean;
    parking: boolean;
}

export interface Address {
    id: number;
    longitude: number;
    latitude: number;
    area: string;
    city: string;
}

export interface Rating {
    id: number;
}

export interface Review {
    id: number;
    name: string;
    date: Date;
    rating: number;
    comment: string;
    image: string;
}

export interface NearestEssential {
    id: number;
    type: string;
    name: string;
    distance: number;
    created_on: Date;
    created_by: string;
}

export interface NearbyPlace {
    id: number;
    name: string;
    distance: number;
    created_on: Date;
    created_by: string;
}

export interface CheckInCheckOuts {
    id: number;
    check_in_from: Date;
    check_out_until: Date;
}

export interface Extras {
    id: number;
    description: string;
    created_by: string;
    created_on: Date;
}

export interface GettingAround {
    id: number;
    description: string;
}

export interface PropertyDetails {
    id: number;
    number_of_floors: string;
    number_of_rooms: string;
    most_recent_renovation: string;
}

export interface HouseRule {
    id: number;
    check_in_check_outs: CheckInCheckOuts;
    extras: Extras;
    getting_around: GettingAround;
    property_details: PropertyDetails;
}

export interface Address {
    id: number;
    longitude: number;
    latitude: number;
    area: string;
    city: string;
}

export interface NearbyHotel {
    id: number;
    name: string;
    address: Address;
}