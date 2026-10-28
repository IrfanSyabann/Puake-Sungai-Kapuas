using System.Collections.Generic;
public class Dialog
{
    // ** NOTE ** //
    //null = Memasuki cutscene layar gelap dan akan muncul suara
    //break = Menampilkan layar kembali tanpa waktu delay
    //gameplay = Character dimainkan oleh 

    public static bool activeDialog = false;
    public static int dialogPage = 0;
    public static List<string> textDialog = new()
    {
        // "Sasa : “Hah…(Menghela nafas) rasanya sudah lama sekali aku tidak pulang ke kampung halamanku.”",
        // "Sasa : “setelah sekian lama merantau untuk berkuliah diluar akhirnya aku bisa bertemu dengan kakek dan nenek juga.”",
        // "Sasa : “kira kira apa kabar mereka yaa…sebaiknya aku memberi kabar ke mereka dulu.”",
        // "<i>Sasa menelpon nenek untuk memberi kabar…</i>",
        // "<i>Telephone nenek memanggil…</i>",
        // "Sasa : “Lohh…kenapa telephone nenek memanggil yaa?(Sasa dengan ekspresi bingung).”",
        // "Sasa : “Oh..mungkin handphone nenek lagi gak ada paket/mati kali yaa..",
        "Sasa : yaudahlah aku kasi surprise aja dengan kedatanganku.”",
        null,
        "<i>Suara bus berhenti, pertanda Sasa sudah tiba di kampung halaman.</i>",
        "break",
        "<i>pemandangan area kampung halaman Sasa(Kota Pontianak).</i>",
        "Sasa : “Emmahh…(Suara lega setelah lama perjalanan),akhirnya sampai juga setelah 8 jam perjalanan.”",
        "<i>Sasa melihat lingkungan sekitar</i>",
        "Sasa : “Hah…suasana di sini ternyata masih sama , tidak terlalu banyak yang berubah.”",
        "Sasa : “tapi justru itu yang membuat aku rindu dengan kampung halamanku.”",
        "Sasa : “baiklah sebaiknya aku langsung ke rumah kakek dan nenek saja.”",
        "gameplay",
        "<i>Sepertinya ada bendera kuning didepan rumah kakek dan nenek</i>",
        "next",
        "<i>Jangan jangan...</i>",
        null,
        "next",
        "Sasa : “Kakek bangun kek…Kakek,Kakek kenapa nek?”",
        "next",
        "Sasa : “kenapa bisa meninggal seperti ini…(Dengan nada tinggi sambil menangis).”",
        "next",
        "<i>Nenek terdiam sambil menangisi kepergiaan kakek dan tidak bisa menjawab pertanyaan Sasa.</i>",
        null,
        "<i>Layar Gelap perlahan namun suara tangisan orang sekitar dan bacaan yasin masih terdengar.</i>",
        "next",
        "Muncul Tulisan Judul Game “Misteri Sungai Kapuas.”",
        "break"
    };

}
