using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using UrganKardesler.Models;

namespace UrganKardesler
{
    public static class SeedData
    {
        public static void MigrateAndAddData(IHost host)
        {
            var servicesProvider = host.Services.CreateScope().ServiceProvider;

            var DbCTX = servicesProvider.GetRequiredService<UrganKardeslerDbCTX>();

            var userManager = servicesProvider.GetRequiredService<UserManager<IdentityUser>>();

            DbCTX.Database.Migrate();

            if (!userManager.Users.Any())
            {
                var newUser = new IdentityUser() { Email = "admin@gmail.com", UserName = "admin" };

                userManager.CreateAsync(newUser, "Password12*").Wait();

                DbCTX.SaveChangesAsync().Wait();
            };

            if (DbCTX.Corporates.Count() < 3)
            {
                DbCTX.Corporates.RemoveRange();

                //DbCTX.Corporates.AddRangeAsync(newCorporates).Wait();
            }

            if (!DbCTX.Blogs.Any())
            {
                var user = userManager.Users.FirstOrDefault();

                var newBlog = new Blog()
                {
                    Title = "Lorem ipsum",
                    Article = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Placerat in egestas erat imperdiet sed. Augue mauris augue neque gravida in fermentum et. Ac odio tempor orci dapibus. Ultrices vitae auctor eu augue ut lectus arcu bibendum. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Justo laoreet sit amet cursus sit amet dictum sit. Mus mauris vitae ultricies leo integer malesuada nunc. Faucibus ornare suspendisse sed nisi. Pretium fusce id velit ut tortor pretium viverra suspendisse potenti. Cras fermentum odio eu feugiat pretium. Eget egestas purus viverra accumsan in. Tincidunt eget nullam non nisi est sit amet facilisis magna. Non quam lacus suspendisse faucibus interdum posuere lorem ipsum dolor. Maecenas sed enim ut sem viverra aliquet eget sit. Non quam lacus suspendisse faucibus interdum posuere lorem ipsum dolor. Volutpat est velit egestas dui id. Aliquet eget sit amet tellus cras adipiscing enim. Purus faucibus ornare suspendisse sed.\r\n\r\nLigula ullamcorper malesuada proin libero nunc consequat interdum varius sit. Feugiat nibh sed pulvinar proin gravida hendrerit. Fermentum iaculis eu non diam. Eu nisl nunc mi ipsum faucibus vitae. Tempus imperdiet nulla malesuada pellentesque elit. Lacus sed turpis tincidunt id. Ridiculus mus mauris vitae ultricies leo integer. Orci nulla pellentesque dignissim enim sit amet. Gravida arcu ac tortor dignissim convallis aenean. Rhoncus est pellentesque elit ullamcorper dignissim cras tincidunt lobortis feugiat. Consectetur lorem donec massa sapien. Arcu non odio euismod lacinia at quis risus sed vulputate. Vitae congue eu consequat ac felis donec et odio. Vitae elementum curabitur vitae nunc sed velit dignissim. Aliquet eget sit amet tellus cras adipiscing enim. Facilisis mauris sit amet massa vitae tortor condimentum. Purus ut faucibus pulvinar elementum. Nunc mattis enim ut tellus elementum sagittis.\r\n\r\nProin sed libero enim sed faucibus turpis. Risus nec feugiat in fermentum. Ut tristique et egestas quis. Nulla facilisi nullam vehicula ipsum a arcu cursus. Consequat id porta nibh venenatis cras sed. Fermentum iaculis eu non diam phasellus vestibulum lorem sed. Tortor pretium viverra suspendisse potenti nullam. Egestas pretium aenean pharetra magna. Cras fermentum odio eu feugiat pretium. Egestas integer eget aliquet nibh praesent tristique magna.\r\n\r\nAmet nisl purus in mollis. Sed felis eget velit aliquet sagittis id consectetur purus. Risus viverra adipiscing at in tellus. Sed lectus vestibulum mattis ullamcorper velit sed. In fermentum et sollicitudin ac. Viverra nibh cras pulvinar mattis nunc sed. Eleifend donec pretium vulputate sapien nec sagittis. Quis risus sed vulputate odio ut enim blandit volutpat maecenas. Tristique senectus et netus et malesuada fames. Integer eget aliquet nibh praesent tristique magna sit. Sed augue lacus viverra vitae congue eu consequat. Pulvinar mattis nunc sed blandit libero. Dolor purus non enim praesent elementum facilisis leo. Sed lectus vestibulum mattis ullamcorper velit sed ullamcorper morbi tincidunt. Augue eget arcu dictum varius duis at consectetur lorem donec. Turpis egestas integer eget aliquet nibh praesent tristique magna sit.\r\n\r\nFermentum leo vel orci porta non pulvinar. Tellus id interdum velit laoreet. Pellentesque elit eget gravida cum. Cursus vitae congue mauris rhoncus aenean vel elit scelerisque mauris. Cras adipiscing enim eu turpis egestas pretium aenean pharetra. Facilisis gravida neque convallis a cras semper. Sed id semper risus in hendrerit gravida rutrum. Urna id volutpat lacus laoreet non. Ac tortor dignissim convallis aenean et tortor at risus. Neque laoreet suspendisse interdum consectetur libero id. Morbi tristique senectus et netus et malesuada fames ac turpis. Nulla porttitor massa id neque aliquam vestibulum morbi blandit. Vel pharetra vel turpis nunc eget lorem dolor sed viverra. Mattis ullamcorper velit sed ullamcorper morbi tincidunt ornare. Bibendum at varius vel pharetra. Et netus et malesuada fames ac turpis egestas sed. Cursus mattis molestie a iaculis at erat pellentesque adipiscing commodo.\r\n\r\nNec ultrices dui sapien eget mi. Tincidunt praesent semper feugiat nibh sed pulvinar proin gravida. Elementum pulvinar etiam non quam lacus suspendisse. Arcu non odio euismod lacinia at. Aenean pharetra magna ac placerat vestibulum lectus mauris. Volutpat sed cras ornare arcu. Condimentum lacinia quis vel eros. Fames ac turpis egestas integer eget aliquet. In hac habitasse platea dictumst vestibulum rhoncus est. Dolor sit amet consectetur adipiscing elit pellentesque habitant. Nulla porttitor massa id neque aliquam vestibulum morbi blandit. Velit aliquet sagittis id consectetur purus ut. Id velit ut tortor pretium viverra suspendisse potenti nullam ac. At erat pellentesque adipiscing commodo. Sit amet nisl suscipit adipiscing bibendum.",
                    ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Placerat in egestas erat imperdiet sed. Augue mauris augue neque gravida in fermentum et. Ac odio tempor orci dapibus. ",
                    AuthorId = user.Id,
                    CreatedDate = DateTime.UtcNow,
                    Category = "Bussines",
                    ThumbnailName = "first.jpg",
                    isActive = true
                };

                DbCTX.Blogs.Add(newBlog);
            }

            DbCTX.SaveChangesAsync().Wait();
        }
    }
}