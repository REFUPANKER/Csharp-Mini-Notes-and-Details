/*

        EXPLAINTATION
if you using aspnet , you will see data only updates
when entire app gets restarted.
so in entity framework we need to use AsNoTracking method
it makes our queries auto executed on page refreshs
  */
public About? ABOUT
		{
			get
			{
				var data = Pool.dbm.AboutData?
					.AsNoTracking()
				.OrderByDescending(a => a.id)
				.FirstOrDefault(); 
				return data;
			}
		}
