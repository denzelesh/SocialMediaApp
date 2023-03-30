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
        Console.WriteLine("    Social Media Application");
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


static void Main(string[] args)
{
    ApplicationHeading();

}
