﻿using StartLine_social_network.Data.Enum;
using StartLine_social_network.Models;

namespace StartLine_social_network.Data
{
    public class Seed
    {
        // Generating random seeds to simply working with data

        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();
                
                // Clubs

                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Club 1",
                            Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fblu-club.business.site%2F&psig=AOvVaw2EOVcoDggqTwli5gjCSufb&ust=1674498441572000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCODujPvm2_wCFQAAAAAdAAAAABAD",
                            Description = "The club description",
                            ClubCategory = ClubCategory.Drinking,
                            Address = new Address()
                            {
                                Street = "Długa 12",
                                City = "Kraków",
                                Province = "Małopolska"
                            }
                         },
                        new Club()
                        {
                            Title = "Club 2",
                            Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fblu-club.business.site%2F&psig=AOvVaw2EOVcoDggqTwli5gjCSufb&ust=1674498441572000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCODujPvm2_wCFQAAAAAdAAAAABAD",
                            Description = "The club description",
                            ClubCategory = ClubCategory.Everything,
                            Address = new Address()
                            {
                                Street = "Długa 12",
                                City = "Kraków",
                                Province = "Małopolska"
                            }
                        },
                        new Club()
                        {
                            Title = " Club 3",
                            Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fblu-club.business.site%2F&psig=AOvVaw2EOVcoDggqTwli5gjCSufb&ust=1674498441572000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCODujPvm2_wCFQAAAAAdAAAAABAD",
                            Description = "The club description",
                            ClubCategory = ClubCategory.Dancing,
                            Address = new Address()
                            {
                                Street = "Długa 12",
                                City = "Kraków",
                                Province = "Małopolska"
                            }
                        },
                        new Club()
                        {
                            Title = "Club 4",
                            Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fblu-club.business.site%2F&psig=AOvVaw2EOVcoDggqTwli5gjCSufb&ust=1674498441572000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCODujPvm2_wCFQAAAAAdAAAAABAD",
                            Description = "The club description",
                            ClubCategory = ClubCategory.HangOut,
                            Address = new Address()
                            {
                                Street = "Długa 12",
                                City = "Kraków",
                                Province = "Małopolska"
                            }
                        }
                    });
                    context.SaveChanges();
                }

                //  Parties
                if (!context.Parties.Any())
                {
                    context.Parties.AddRange(new List<Party>()
                    {
                        new Party()
                        {
                            Title = "Party 1",
                            Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fblu-club.business.site%2F&psig=AOvVaw2EOVcoDggqTwli5gjCSufb&ust=1674498441572000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCODujPvm2_wCFQAAAAAdAAAAABAD",
                            Description = "This is a party description",
                            PartyClubCategory = PartyClubCategory.Night,
                            Address = new Address()
                            {
                                Street = "Długa 12",
                                City = "Kraków",
                                Province = "Małopolska"
                            }
                        },
                        new Party()
                        {
                            Title = "Party 2",
                            Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fblu-club.business.site%2F&psig=AOvVaw2EOVcoDggqTwli5gjCSufb&ust=1674498441572000&source=images&cd=vfe&ved=0CBAQjRxqFwoTCODujPvm2_wCFQAAAAAdAAAAABAD",
                            Description = "This a party description",
                            PartyClubCategory = PartyClubCategory.Pub,
                            AddressId = 5,
                            Address = new Address()
                            {
                               Street = "Długa 12",
                                City = "Kraków",
                                Province = "Małopolska"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}