using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bknsystem.privateApi.Dtos;
using bknsystem.privateApi.Helpers;
using bknsystem.privateApi.Interfaces;
using bknsystem.privateApi.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace bknsystem.privateApi.Repositories
{
    public class HotelRepository : IHotelRepository
    {

        private IMapper _mapper;
        private readonly IMongoCollection<hotel> _hotels;
        private readonly Datalayer _db;

        public HotelRepository(IHotelDatabaseSettings settings, Datalayer db)
        {
            _db = db;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _hotels = database.GetCollection<hotel>(settings.HotelsCollectionName);

            // _mapper = mapper;
        }
        public PagedList<HotelListSummary_Dto> GetHotelListSummaries(RequestParams requestParams = default)
        {
            var hotel_summary = _db.hotel.AsNoTracking().Include(a => a.address).AsQueryable();
            foreach (var filter in requestParams.GetFilters())
            {
                if (filter.Field == "city")
                {
                    hotel_summary = hotel_summary.Where(h => h.address.city == filter.Value.ToString());
                }

                if (filter.Field == "hotel_name" && filter.Value.ToString()!="undefined")
                {
                    hotel_summary = hotel_summary.Where(h => EF.Functions.Like(h.hotel_name, $"%{filter.Value}%"));
                }

                if (filter.Field == "rooms")
                {
                    hotel_summary = hotel_summary.Where(h => h.rooms.Any(r => r.room_beds.ToString().Contains(filter.Value.ToString())));
                }
                if(filter.Field=="stars"){
                    hotel_summary=hotel_summary.Where(h=>h.stars.ToString().Contains(filter.Value.ToString()));
                }
            }

            var config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<hotel, HotelListSummary_Dto>();
              });
            _mapper = config.CreateMapper();
          
            var hotel_summary_list = _mapper.Map<List<HotelListSummary_Dto>>(hotel_summary.OrderByDescending(m=>m.stars).ToList());

            var hotelLatest = hotel_summary_list.AsQueryable();
            
            // // return PagedList<HotelListSummary_Dto>.CreateAsync(hotelLatest, hotelSearchFilter.PageNumber, hotelSearchFilter.PageSize);


            // // return await PagedList<EmployeePayments>.CreateAsync(hotel, hotelSearchFilter.PageNumber, hotelSearchFilter.PageSize);


            // if (!string.IsNullOrWhiteSpace(hotelSearchFilter.) && hotelSearchFilter.name != "undefined")
            // {
            //     hotels = hotels.Where(c => EF.Functions.Like(c.name, hotelSearchFilter.name + "%%"));
            // }

            // if (hotelSearchFilter.account != 0)
            // {
            //     hotels = hotels.Where(c => c.account == hotelSearchFilter.account);
            // }
            // if (hotelSearchFilter.FromDate != null || hotelSearchFilter.ToDate != null)
            // {
            //     hotels = hotels.Where(c => c.payment_date >= hotelSearchFilter.FromDate && c.payment_date <= hotelSearchFilter.ToDate);
            // }
            // if (!string.IsNullOrEmpty(hotelSearchFilter.OrderBy))
            // {
            //     switch (hotelSearchFilter.OrderBy)
            //     {

            //         default:
            //             hotels = hotels.OrderByDescending(c => c.payment_date);
            //             break;
            //     }
            // }

            return PagedList<HotelListSummary_Dto>.CreateAsync(hotelLatest, 1, 200);
        }



        public hotel GetHotelById(string id) =>
               _db.hotel.Find(id);


        public List<HotelListSummary_Dto> GetHotelSummaryList()
        {

            var hotel_summary = _hotels.Find(hotel => true).ToList();

            //var test = _hotels.Aggregate().Unwind("stars").Group(new BsonDocument{{"_id", "$_id"}, {""}})
            List<HotelListSummary_Dto> hotel_summary_list = new List<HotelListSummary_Dto>();

            var config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<hotel, HotelListSummary_Dto>();
              });
            _mapper = config.CreateMapper();
            hotel_summary_list = _mapper.Map<List<HotelListSummary_Dto>>(hotel_summary);
            return hotel_summary_list;
        }


        public hotel Create(HotelCreateForm_Dto hotelCreateForm_)
        {
            hotel hotel_form = new hotel();

            var config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<HotelCreateForm_Dto, hotel>();
              });
            _mapper = config.CreateMapper();
            hotel_form = _mapper.Map<hotel>(hotelCreateForm_);

            _db.Add(hotel_form);
            _db.SaveChanges();
            return hotel_form;
        }



        public string UpdateHotel(string id, hotel hotelUpdateForm)
        {

            if (id != hotelUpdateForm.id)
            {
                return "Not Found";
            }

            _db.Entry(hotelUpdateForm).State = EntityState.Modified;

            try
            {
                 _db.SaveChanges();
                return "Successfully Updated Hotel";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }


        public string DeleteHotel(string id)
        {


            var hotel =  _db.hotel.Find(id);
            if (hotel == null)
            {
                return "Not Found";
            }

            try
            {
                _db.hotel.Remove(hotel);
                _db.SaveChanges();

                return "Deleted";
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        
    }
}