class Post
{
/* This class serves as the default for a post and its attributes,
    All posts created will share all these common attributes
*/
    public string content;
    public string author;
    public int likeAmount;
    public int commentAmount;

    public Post(string content, string author)
    {
        this.content = content;
        this.author = author;
        this.likeAmount = 0;
        this.commentAmount = 0;
    }
}

class ImagePost : Post
{
/* This class inherits attributes from the Post Class and 
creates a subclass with an added 'image path' attribute which 
diffentiates this type of post.

*/
    public string imagePath;

    public ImagePost(string imagePath, string author)
        : base("", author)
    {
        this.imagePath = imagePath;
    }
}

class SocialMediaApp
{
    static List<Post> posts = new List<Post>();

    static void ApplicationHeading()
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("    App 05 - Social Media Application");
        Console.WriteLine("         By Denzel Eshun");
        Console.WriteLine("-----------------------------------");
    }

    static void CreatePost()
    {
        Console.Write("Enter your name ");
        string author = Console.ReadLine();

        Console.WriteLine("Select Post Type");
        Console.WriteLine("1. Text-Based Post");
        Console.WriteLine("2. Image Post");
        Console.Write("Select Post Type (1 or 2): ");
        int postType = int.Parse(Console.ReadLine());

            if (postType == 1)
    {
        Console.Write("Enter your post's text: ");
        string content = Console.ReadLine();

        Post post = new Post(content, author);
        posts.Add(post);

        Console.WriteLine("Your post has been created!");
    }
    else if (postType == 2)
    {
        Console.Write("Enter link to the image you want to post: ");
        string imagePath = Console.ReadLine();

        ImagePost imagePost = new ImagePost(imagePath, author);
        posts.Add(imagePost);

        Console.WriteLine("Image post created successfully!");
    }
    else
    {
        Console.WriteLine("Incorrect post type selected.");
    }
}


static void ShowPosts()
{
/* This method displays the the posts created depenidng on 
The users menuOption.
*/
    Console.WriteLine("Show posts by:");
    Console.WriteLine("1. Author");
    Console.WriteLine("2. Show All");
    Console.Write("Choose post sorting (1 or 2): ");
    int menuOption = int.Parse(Console.ReadLine());

    if (menuOption == 1)
    {
    /* This code displays a list of posts by a specific author and 
        loops through posts with the entered author name.
    */
        Console.Write("Enter author name: ");
        string author = Console.ReadLine();

        List<Post> authorPosts = posts.FindAll(post => post.author == author);

        Console.WriteLine($"Posts by {author}:");
        for (int i = 0; i < authorPosts.Count; i++)
        {
            Console.WriteLine($"[{i}] - {authorPosts[i].content} ({authorPosts[i].likeAmount} likes, {authorPosts[i].commentAmount} comments)");
        }
    }
    else if (menuOption == 2)
    {
        /* This code displays all  posts by and 
        loops through them to show them
        */
        Console.WriteLine("All posts:");
        for (int i = 0; i < posts.Count; i++)
        {
            if (posts[i] is ImagePost)
            {
                Console.WriteLine($"[{i}] - Image Post: {((ImagePost)posts[i]).imagePath} ({posts[i].author}, {posts[i].likeAmount} likes, {posts[i].commentAmount} comments)");
            }
            else
            {
                Console.WriteLine($"[{i}] - Text Post: {posts[i].content} ({posts[i].author}, {posts[i].likeAmount} likes, {posts[i].commentAmount} comments)");
            }
        }
    }
    else
    {
        Console.WriteLine("Invalid option entered.");
        return;
    }
    /* 
    This code prompts the user to enter the index of a post they want to delete and read
    */
    Console.Write("Enter the index of the post you want to delete (-1 to cancel): ");
    int index = int.Parse(Console.ReadLine());

    if (index >= 0 && index < posts.Count)
    {
        posts.RemoveAt(index);
        Console.WriteLine("Post deleted successfully!");
    }
    else if (index != -1)
    {
        Console.WriteLine("Invalid index entered. Post not deleted.");
    }
}

static void Main(string[] args)
{
    ApplicationHeading();
    while (true)
    /* This loop shows a menu and runs the appropriate method.
    This loop also ensure the program does not terminate itself
    Also using parse to verify the option chosen*/
    {
        Console.WriteLine(" ");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Create a post");
        Console.WriteLine("2. View posts");
        Console.WriteLine("3. Close App");
        Console.Write("Enter your choice (1, 2, or 3): ");
        int menuOption = int.Parse(Console.ReadLine());
        switch (menuOption)
        {
            case 1:
                CreatePost();
                break;
            case 2:
                ShowPosts();
                break;
            case 3:
                Console.WriteLine("Until we meet again...");
                return;
            default:
                Console.WriteLine("Invalid option entered.");
                break;
        }
}
}

}
