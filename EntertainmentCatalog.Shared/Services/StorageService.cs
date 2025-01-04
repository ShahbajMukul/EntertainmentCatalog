using EntertainmentCatalog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EntertainmentCatalog.Shared.Services
{
    /// <summary>
    /// Service for storing and retrieving review details.
    /// </summary>
    public class StorageService
    {
        // Path to the file where reviews are stored.
        private readonly string fileLocation;

        /// <summary>
        /// Constructs the full path to a file named "reviews.json" located in the "Application Data" folder.
        /// </summary>
        public StorageService()
        {
            fileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "reviews.json");
        }

        /// <summary>
        /// Saves a new review to the storage file.
        /// </summary>
        /// <param name="newReview">The review details to save.</param>
        public void SaveReview(ReviewDetails newReview)
        {
            // Get all existing reviews
            var reviews = LoadReviews() ?? new List<ReviewDetails>();
            reviews.Add(newReview);
            File.WriteAllText(fileLocation, JsonSerializer.Serialize(reviews));
        }

        /// <summary>
        /// Loads all reviews from the storage file.
        /// </summary>
        /// <returns>An list of review details.</returns>
        public List<ReviewDetails> LoadReviews()
        {
            if (!File.Exists(fileLocation))
            {
                return new List<ReviewDetails>();
            }

            var reviewJson = File.ReadAllText(fileLocation);

            try
            {
                return JsonSerializer.Deserialize<List<ReviewDetails>>(reviewJson);
            }
            catch (JsonException)
            {
                // If deserialization into a list fails, attempt to deserialize a single object
                var singleReview = JsonSerializer.Deserialize<ReviewDetails>(reviewJson);
                if (singleReview != null)
                {
                    return new List<ReviewDetails> { singleReview };
                }
                else
                {
                    throw; // Re-throw the exception if deserialization fails
                }
            }
        }
    }
}
